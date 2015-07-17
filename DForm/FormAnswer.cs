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
            return questionBase.FindAnswer();
        }

        public AnswerBase AddAnswerFor( QuestionBase questionBase )
        {
            AnswerBase anwserBase = (AnswerBase)Activator.CreateInstance( Type.GetType( "DForm." + (questionBase.GetType().Name).Replace( "Question", "Answer" ) + ",DForm" ) );
            anwserBase.Title = questionBase.Title;
            anwserBase.Index = questionBase.Index;
            anwserBase.Parent = questionBase.Parent;
            return anwserBase;
        }

        public string UniqueName
        {
            get { return _uniqueName; }
            set { _uniqueName = value; }
        }

    }
}
