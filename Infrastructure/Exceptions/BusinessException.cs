using System;

namespace FengSharp.OneCardAccess.Infrastructure.Exceptions
{
    [System.Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }
        public BusinessException(string message)
            : base(message)
        {
        }
        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected BusinessException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        //public static void HandlerError(int code)
        //{
        //    if (code == -1)
        //    {
        //        throw new BusinessException(ResourceMessages.InsertFailed);
        //    }
        //    else if (code == -2)
        //    {
        //        throw new BusinessException(ResourceMessages.UpdateFailed);
        //    }
        //    else if (code == -3)
        //    {
        //        throw new BusinessException(ResourceMessages.DeleteFailed);
        //    }
        //    else if (code == -4)
        //    {
        //        throw new BusinessException(ResourceMessages.ExistSameNo);
        //    }
        //    else if (code == -5)
        //    {
        //        throw new BusinessException(ResourceMessages.BeReferencedCanNotDelete);
        //    }
        //    else if (code == -6)
        //    {
        //        throw new BusinessException(ResourceMessages.HasSonCanNotDelete);
        //    }
        //}
        //public static void HandlerUnKnowError(int code)
        //{
        //    if (code != 0)
        //        throw new BusinessException("未处理的错误");
        //}
    }
}
