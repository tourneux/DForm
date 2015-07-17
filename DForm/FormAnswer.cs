using System;
using System.Collections.Generic;

namespace DForm
{
    public class FormAnswer
    {
        private string _uniqueName;
        private Form Form;

        public FormAnswer( string answerTitle, Form form )
        {
            _uniqueName = answerTitle;
            Form = form;
        }
    
        public AnswerBase FindAnswer( QuestionBase questionBase )
        {
            //Dictionary<QuestionBase, AnswerBase> dictionary = questionBase.Parent.dictionary;
            //foreach( KeyValuePair<QuestionBase, AnswerBase> entry in dictionary )
            //{
            //    if(entry.Key == questionBase)
            //    {
            //        return entry.Value;
            //    }
            //}
            return null;
        }

        public string UniqueName
        {
            get { return _uniqueName; }
            set { _uniqueName = value; }
        }

    }
}
