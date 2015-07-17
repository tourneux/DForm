using System;
using System.Collections.Generic;

namespace DForm
{
    public abstract class QuestionBase : ITitle
    {
        readonly Form _form;
        private string _title;
        private int _index;
        private QuestionBase _parent;
        readonly Dictionary<QuestionBase, AnswerBase> dictionary;

        public QuestionBase( )
        {
            dictionary = new Dictionary<QuestionBase, AnswerBase>();
        }

        public int Index
        {
            get { return _index; }
            set
            {
                if( this._parent != null &&  this._parent.dictionary != null && this._parent.dictionary.Count > 0 )
                {
                    if ( value == -1 )
                    {
                        foreach( var qBase in _parent.dictionary.Keys )
                        {
                            if( qBase._index > this._index )
                            {
                                qBase._index -= 1;
                            }
                            else if( qBase._index == this._index )
                            {
                                qBase._index = value;
                            }
                        }
                    }
                    else if( _index > value )
                    {
                        foreach( var qBase in _parent.dictionary.Keys )
                        {
                            if( qBase._index >= value && qBase._index < this._index )
                            {
                                qBase._index += 1;
                            }
                            else if( qBase._index == this._index )
                            {
                                qBase._index = value;
                            }
                        }
                    }
                    else
                    {
                        foreach( var qBase in _parent.dictionary.Keys )
                        {
                            if( qBase._index >= this._index && qBase._index < value )
                            {
                                qBase._index -= 1;
                            }
                            else if( qBase._index == this._index )
                            {
                                qBase._index = value;
                            }
                        }
                    }
                }
                else
                {
                    _index = value;
                }
            }
        }

        public QuestionBase Parent
        {
            get { return _parent; }
            set
            {
                if( value == null )
                {
                    Index = -1;
                    _parent = null;
                }
                else
                {
                    _parent = value; 
                }
            }
        }

        public virtual Form Form
        {
            get { return _form != null ? _form : null; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value;  }
        }

        public virtual QuestionBase AddNewQuestion( string type )
        {
            return AddNewQuestion( Type.GetType( type ) );
        }

        public virtual QuestionBase AddNewQuestion( Type t )
        {
            if( !typeof( QuestionBase ).IsAssignableFrom( t ) ) throw new ArgumentException( "The type Must be a QuestionBase" );
            QuestionBase qb = (QuestionBase)Activator.CreateInstance( t );
            qb.Parent = this;
            dictionary.Add( qb, null );
            return qb;
        }

        public Dictionary<QuestionBase, AnswerBase> Dictionary
        {
            get { return dictionary; }
        }

        public AnswerBase FindAnswer()
        {
            Dictionary<QuestionBase, AnswerBase> dictionary = this._parent.Dictionary;

            foreach( KeyValuePair<QuestionBase, AnswerBase> entry in dictionary )
            {
                if( entry.Key == this )
                {
                    return entry.Value;
                }
            }
            return null;
        }
    }
}
