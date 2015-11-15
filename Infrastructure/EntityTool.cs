using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class EntityTool
    {
        static Dictionary<string, Func<object>> dicModifyFields = new Dictionary<string, Func<object>>();
        static Dictionary<string, Func<object>> dicCreateAndModifyFields = new Dictionary<string, Func<object>>();
        private static void CreateDicCreateAndModifyFields()
        {
            AuthIdentity authidentity = ApplicationContext.Current.AuthPrincipal.Identity as AuthIdentity;
            lock (dicCreateAndModifyFields)
            {
                if (!dicCreateAndModifyFields.ContainsKey("LastModifyId"))
                    dicCreateAndModifyFields.Add("LastModifyId", () =>
                    {
                        return authidentity.UserId;
                    });
                if (!dicCreateAndModifyFields.ContainsKey("LastModifyName"))
                    dicCreateAndModifyFields.Add("LastModifyName", () =>
                    {
                        return authidentity.UserName;
                    });
                if (!dicCreateAndModifyFields.ContainsKey("LastModifyDate"))
                    dicCreateAndModifyFields.Add("LastModifyDate", () =>
                    {
                        return DateTime.Now;
                    });
                if (!dicCreateAndModifyFields.ContainsKey("CreateId"))
                    dicCreateAndModifyFields.Add("CreateId", () =>
                    {
                        return authidentity.UserId;
                    });
                if (!dicCreateAndModifyFields.ContainsKey("CreateName"))
                    dicCreateAndModifyFields.Add("CreateName", () =>
                    {
                        return authidentity.UserName;
                    });
                if (!dicCreateAndModifyFields.ContainsKey("CreateDate"))
                    dicCreateAndModifyFields.Add("CreateDate", () =>
                    {
                        return DateTime.Now;
                    });
            }
        }
        private static void CreateDicModifyFields()
        {
            AuthIdentity authidentity = ApplicationContext.Current.AuthPrincipal.Identity as AuthIdentity;
            lock (dicModifyFields)
            {
                if (!dicModifyFields.ContainsKey("LastModifyId"))
                    dicModifyFields.Add("LastModifyId", () =>
                    {
                        return authidentity.UserId;
                    });
                if (!dicModifyFields.ContainsKey("LastModifyName"))
                    dicModifyFields.Add("LastModifyName", () =>
                    {
                        return authidentity.UserName;
                    });
                if (!dicModifyFields.ContainsKey("LastModifyDate"))
                    dicModifyFields.Add("LastModifyDate", () =>
                    {
                        return DateTime.Now;
                    });
            }
        }
        public static void CopyCreateAndModify(object obj)
        {
            if (obj == null)
                return;
            if (dicCreateAndModifyFields.Count <= 0)
            {
                CreateDicCreateAndModifyFields();
            }
            var type = obj.GetType();
            foreach (FieldInfo fi in type.GetFields())
            {
                if (dicCreateAndModifyFields.Keys.Contains(fi.Name))
                {
                    fi.SetValue(obj, dicCreateAndModifyFields[fi.Name]());
                }
            }
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (dicCreateAndModifyFields.Keys.Contains(pi.Name))
                {
                    pi.SetValue(obj, dicCreateAndModifyFields[pi.Name](), null);
                }
            }
        }
        public static void CopyModify(object obj)
        {
            if (obj == null)
                return;
            if (dicModifyFields.Count <= 0)
            {
                CreateDicModifyFields();
            }
            var type = obj.GetType();
            foreach (FieldInfo fi in type.GetFields())
            {
                if (dicModifyFields.Keys.Contains(fi.Name))
                {
                    fi.SetValue(obj, dicModifyFields[fi.Name]());
                }
            }
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (dicModifyFields.Keys.Contains(pi.Name))
                {
                    pi.SetValue(obj, dicModifyFields[pi.Name](), null);
                }
            }
        }
    }
}
