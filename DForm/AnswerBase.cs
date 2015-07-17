using System;

namespace DForm
{
    public abstract class AnswerBase
    {
        public AnswerBase AddAnswerFor( QuestionBase questionBase )
        {
            return (AnswerBase)Activator.CreateInstance( Type.GetType( (questionBase.GetType().Name).Replace( "([a-zA-Z]+)Question", "$1Answer" ) ) );
        }
    }
}
