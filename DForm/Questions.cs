using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace DForm
{
    public class Questions : QuestionBase
    {
        readonly Form _form;
        private string title;
        private int _currentIndex;

        public Questions( Form form )
        {
            _form = form;
        }

        public Boolean Contains(QuestionBase questionBase)
        {
            if( questionBase == null ) throw new ArgumentNullException();
            if (questionBase == this) {
                return true;
            } else {
                do
                {
                    questionBase = questionBase.Parent;
                    if( questionBase.Parent == this ) return true;
                }
                while( questionBase.Parent != this && questionBase != null );
                return false;
            }
        }

        public QuestionBase AddNewQuestion( string type ) 
        {
            return AddNewQuestion( Type.GetType( type ) );
        }

        public QuestionBase AddNewQuestion( Type t )
        {
            if( !typeof( QuestionBase ).IsAssignableFrom( t ) ) throw new ArgumentException( "The type Must be a QuestionBase" );
            QuestionBase qb = (QuestionBase)Activator.CreateInstance( t );
            qb.Index = _currentIndex++;
            qb.Parent = this;
            this.Form.FindOrCreateAnswer( this.Form.Title ).Add( qb, null );
            return qb;
            //return (QuestionBase)Activator.CreateInstance( t, _currentIndex, this );
        }


        public override Form Form {
            get { return _form; } 
        }
        
        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
                this._form.Title = value;
            }
        }
    }
}
