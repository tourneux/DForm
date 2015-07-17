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
        private List<QuestionBase> _child;

        public QuestionBase( )
        { }

        //public QuestionBase( int index, QuestionBase question )
        //{
        //    _index = index--;
        //    Parent = question;
        //}

        public int Index
        {
            get { return _index; }
            set { _index = value; }
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
                    if( value._child == null )
                    {
                        value._child = new List<QuestionBase>();
                        Index = 0;
                    } 
                    else
                    {
                        Index = value._child.Count;
                    }
                    value._child.Add( this );
                }
                Index = 0; //////   A faire !!!!!
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
    }
}
