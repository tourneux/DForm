using System;
using System.Web;

namespace DForm
{
    public class OpenAnswer : AnswerBase
    {
        private string _freeAnswer;
        private bool _allowEmptyAnswer;

        public bool AllowEmptyAnswer
        {
            get { return _allowEmptyAnswer; }
            set { _allowEmptyAnswer = value; }
        }

        public string FreeAnswer
        {
            get { return _freeAnswer; }
            set { _freeAnswer = value; }
        }
    }
}
