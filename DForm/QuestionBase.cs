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
        public Dictionary<QuestionBase, AnswerBase> dictionary;

        public QuestionBase( )
        { }

        public int Index
        {
            get { return _index; }
            set
            {
                if( _parent != null &&  _parent.dictionary != null && _parent.dictionary.Count > 0 )
                {
                    if( _index > value )
                    {
                        foreach( var qBase in _parent.dictionary.Keys )
                        {
                            if( qBase.Index >= value && qBase.Index < this._index )
                            {
                                qBase.Index++;
                            }
                            if( qBase.Index == this._index )
                            {
                                qBase.Index = value;
                            }
                        }
                    }
                    else
                    {
                        foreach( var qBase in _parent.dictionary.Keys )
                        {
                            if( qBase.Index >= this._index && qBase.Index < value )
                            {
                                qBase.Index--;
                            }
                            if( qBase.Index == this._index )
                            {
                                qBase.Index = value;
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
                }
                else
                {
                    if( typeof( Questions ) != value.GetType() )
                    {
                        if( value.dictionary == null )
                        {
                            value.dictionary = new Dictionary<QuestionBase,AnswerBase>();
                            Index = 0;
                        }
                        else
                        {
                            Index = value.dictionary.Count;
                        }
                        value.dictionary.Add( this, null );
                    }
                }
                _parent = value;
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

    }
}
