using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace DForm
{
    public class Questions : QuestionBase
    {
        private string title;
        private int _currentIndex;

        public Questions( Form form ) : base( form )
        {
            Title = form.Title;
        }

        public Boolean Contains(QuestionBase questionBase)
        {
            if( questionBase == null ) throw new ArgumentNullException();
            if( questionBase == this || questionBase.Parent.Parent == null )
            {
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
            this.Dictionary.Add( qb, null );
            qb.Parent = this;
            return qb;
        }


        public override Form Form {
            get { return base.Form; }
        }
        
        public new string Title
        {
            get { return title; }
            set 
            {
                title = value;

                if( value != null ) {
                    Form.Title = value;
                }
            }
        }
    }
}
