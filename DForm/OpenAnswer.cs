using System;
using System.Web;

namespace DForm
{
    public class OpenAnswer : AnswerBase
    {
        private string _freeAnswer;

        public string FreeAnswer
        {
            get { return _freeAnswer; }
            set { _freeAnswer = value; }
        }
    }
}
