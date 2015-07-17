using System;
using System.Collections.Generic;

namespace DForm
{
    public class FormAnswer
    {
        private string _uniqueName;
        private Form Form;
        private Dictionary<QuestionBase, AnswerBase> dictionary;

        public FormAnswer( string answerTitle, Form form )
        {
            _uniqueName = answerTitle;
            Form = form;
        }
    
        public AnswerBase FindAnswer( QuestionBase questionBase)
        {
            foreach( KeyValuePair<QuestionBase, AnswerBase> entry in dictionary )
            {
                if(entry.Key == questionBase)
                {
                    return entry.Value;
                }
            }
            return null;
        }

        public string UniqueName
        {
            get { return _uniqueName; }
            set { _uniqueName = value; }
        }

        public void Add(QuestionBase questionBase, AnswerBase answerBase)
        {
            if( questionBase == null ) throw new ArgumentNullException();
            if( dictionary == null) 
            {
                dictionary = new Dictionary<QuestionBase, AnswerBase>();
            } 
            dictionary.Add( questionBase, answerBase );
        }
    }
}
