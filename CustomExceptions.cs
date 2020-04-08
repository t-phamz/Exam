//20183732_Tommy_Pham
using System;
using System.Runtime.Serialization;

namespace _20183732_Tommy_Pham
{

    [Serializable]
    public class InsufficientCreditsException : Exception
    {

        public InsufficientCreditsException()
        { }

        // Constructors
        public InsufficientCreditsException(string message)
            : base(message)
        { }
    }

    [Serializable]
    public class ProductNotActiveException : Exception
    {
        public ProductNotActiveException()
        { }

        public ProductNotActiveException(string message) : base(message)
        { }

    }

    [Serializable]
    public class CannotBeNullException : Exception
    {
        public CannotBeNullException()
        { }

        public CannotBeNullException(string message): base(message)
        { }

    }


}

