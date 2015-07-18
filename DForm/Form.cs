using System;
using System.Collections.Generic;

namespace DForm
{
    public class Form : ICloneable, ITitle
    {
        public Questions Questions;
        private List<FormAnswer> _formAnswer;
        private string title;

        public Form()
        {
            Questions = new Questions( this );
            _formAnswer = new List<FormAnswer>();
        }

        public FormAnswer FindOrCreateAnswer( string answerTitle )
        {
            if( answerTitle == null ) throw new ArgumentNullException();
            foreach( FormAnswer answer in _formAnswer )
            {
                if( answer.UniqueName == answerTitle )
                {
                    return answer;
                }
            }
            FormAnswer formAnswer = new FormAnswer( answerTitle, this );
            _formAnswer.Add( formAnswer );
            return formAnswer;
        }

        public int AnswerCount
        {
            get { return this._formAnswer.Count; }
        }

        public string Title {
            get { return title; }
            set 
            { 
                title = value;

                if( Questions != null && Questions.Title == null )
                {
                    Questions.Title = value;
                }
            }
        }

        public List<FormAnswer> ListOfFormAnswer
        {
            get { return _formAnswer; }
            set
            {
                _formAnswer = value;
            }
        }

        private object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public object Clone()
        {
            Form cloned = (Form)this.ShallowCopy();
            cloned.ListOfFormAnswer = new List<FormAnswer>();
            return cloned;
        }

    }
}
