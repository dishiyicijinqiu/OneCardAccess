using FengSharp.OneCardAccess.Domain.BSSModule.Entity;
using FengSharp.OneCardAccess.Infrastructure.Exceptions;

namespace FengSharp.OneCardAccess.Presentation.IntegeatedManage.BSS
{
    public class DJSHChecker
    {

        /// <summary>
        /// 检查后面的审核流程是否有一个完成
        /// </summary>
        internal static bool CheckAfterInputLevel(DlyNdxEntity entity, short totalInputLevel, short inputlevel)
        {
            switch (inputlevel)
            {
                default:
                    throw new BusinessException("非法的审核级别");
                case 5:
                    return true;
                case 4:
                    {
                        if (totalInputLevel > 4 && !string.IsNullOrWhiteSpace(entity.SHRId5))
                            return true;
                        return false;
                    }
                case 3:
                    {
                        if (totalInputLevel > 3 && !string.IsNullOrWhiteSpace(entity.SHRId4))
                            return true;
                        if (totalInputLevel > 4 && !string.IsNullOrWhiteSpace(entity.SHRId5))
                            return true;
                        return false;
                    }
                case 2:
                    {
                        if (totalInputLevel > 2 && !string.IsNullOrWhiteSpace(entity.SHRId3))
                            return true;
                        if (totalInputLevel > 3 && !string.IsNullOrWhiteSpace(entity.SHRId4))
                            return true;
                        if (totalInputLevel > 4 && !string.IsNullOrWhiteSpace(entity.SHRId5))
                            return true;
                        return false;
                    }
                case 1:
                    {
                        if (totalInputLevel > 1 && !string.IsNullOrWhiteSpace(entity.SHRId2))
                            return true;
                        if (totalInputLevel > 2 && !string.IsNullOrWhiteSpace(entity.SHRId3))
                            return true;
                        if (totalInputLevel > 3 && !string.IsNullOrWhiteSpace(entity.SHRId4))
                            return true;
                        if (totalInputLevel > 4 && !string.IsNullOrWhiteSpace(entity.SHRId5))
                            return true;
                        return false;
                    }
            }
        }
        /// <summary>
        /// 检查前面的审核流程是否全部完成
        /// </summary>
        internal static bool CheckPreInputLevel(DlyNdxEntity entity, short inputlevel)
        {
            switch (inputlevel)
            {
                default:
                    throw new BusinessException("非法的审核级别");
                case 1:
                    return true;
                case 2:
                    {
                        if (string.IsNullOrWhiteSpace(entity.SHRId1))
                            return false;
                        return true;
                    }
                case 3:
                    {
                        if (string.IsNullOrWhiteSpace(entity.SHRId1))
                            return false;
                        if (string.IsNullOrWhiteSpace(entity.SHRId2))
                            return false;
                        return true;
                    }
                case 4:
                    {
                        if (string.IsNullOrWhiteSpace(entity.SHRId1))
                            return false;
                        if (string.IsNullOrWhiteSpace(entity.SHRId2))
                            return false;
                        if (string.IsNullOrWhiteSpace(entity.SHRId3))
                            return false;
                        return true;
                    }
                case 5:
                    {
                        if (string.IsNullOrWhiteSpace(entity.SHRId1))
                            return false;
                        if (string.IsNullOrWhiteSpace(entity.SHRId2))
                            return false;
                        if (string.IsNullOrWhiteSpace(entity.SHRId3))
                            return false;
                        if (string.IsNullOrWhiteSpace(entity.SHRId4))
                            return false;
                        return true;
                    }
            }
        }
    }
}
