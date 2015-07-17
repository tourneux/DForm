using System;

namespace DForm
{
    public class OpenQuestion : QuestionBase
    {
        private bool _allowEmptyAnswer;

        public bool AllowEmptyAnswer
        {
            get { return _allowEmptyAnswer; }
            set { _allowEmptyAnswer = value; }
        }
    }
}
