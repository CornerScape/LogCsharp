using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ThirdParty.Util;

namespace ThirdParty.Debug
{
    public static class Log
    {
        public static int ShowTag = 1;

        [Conditional("LOG_INFO")]
        public static void Info(object InMsg, ColorName InColorName = ColorName.Default, int InTag = 1)
        {
            if ((InTag & ShowTag) != InTag)
                return;
            UnityEngine.Debug.Log(InColorName == ColorName.Default
                ? InMsg
                : $"<color={ColorUtil.GetColorHex(InColorName)}>{InMsg}</color>");
        }

        [Conditional("LOG_INFO")]
        public static void Info(object InMsg, UnityEngine.Object InContext, ColorName InColorName = ColorName.Default,
            int InTag = 1)
        {
            if ((InTag & ShowTag) != InTag)
                return;
            UnityEngine.Debug.Log(InColorName == ColorName.Default
                    ? InMsg
                    : $"<color={ColorUtil.GetColorHex(InColorName)}>{InMsg}</color>"
                , InContext);
        }

        [Conditional("LOG_INFO")]
        public static void Info<T>(string InMsg, T[] InArray, ColorName InColorName = ColorName.Default, int InTag = 1)
        {
            if ((InTag & ShowTag) != InTag)
                return;

            if (InColorName == ColorName.Default)
            {
                if (null == InArray)
                {
                    UnityEngine.Debug.Log($"{InMsg}\nArray is null.");
                }
                else
                {
                    int len = InArray.Length;
                    if (0 == len)
                    {
                        UnityEngine.Debug.Log($"{InMsg}\nArray is empty.");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(InMsg).Append("\n");
                        sb.Append("[<").Append(0).Append(", ").Append(InArray[0]).Append(">");
                        for (int i = 1; i < len; i++)
                        {
                            sb.Append(", <").Append(i).Append(", ").Append(InArray[i]).Append(">");
                        }

                        sb.Append("]");
                        UnityEngine.Debug.Log(sb.ToString());
                    }
                }
            }
            else
            {
                string colorHex = ColorUtil.GetColorHex(InColorName);

                if (null == InArray)
                {
                    UnityEngine.Debug.Log(
                        $"<color={colorHex}>{InMsg}</color>\n<color={colorHex}>Array is null.</color>");
                }
                else
                {
                    int len = InArray.Length;
                    if (0 == len)
                    {
                        UnityEngine.Debug.Log(
                            $"<color={colorHex}>{InMsg}</color>\n<color={colorHex}>Array is empty.</color>");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<color=").Append(colorHex).Append(">").Append(InMsg).Append("</color>\n<color=")
                            .Append(colorHex).Append(">");
                        sb.Append("[<").Append(0).Append(", ").Append(InArray[0]).Append(">");
                        for (int i = 1; i < len; i++)
                        {
                            sb.Append(", <").Append(i).Append(", ").Append(InArray[i]).Append(">");
                        }

                        sb.Append("]").Append("</color>");
                        UnityEngine.Debug.Log(sb.ToString());
                    }
                }
            }
        }

        [Conditional("LOG_INFO")]
        public static void Info<T>(string InMsg, List<T> InList, ColorName InColorName = ColorName.Default,
            int InTag = 1)
        {
            if ((InTag & ShowTag) != InTag)
                return;

            if (InColorName == ColorName.Default)
            {
                if (null == InList)
                {
                    UnityEngine.Debug.Log($"{InMsg}\nList is null.");
                }
                else
                {
                    int count = InList.Count;
                    if (0 == count)
                    {
                        UnityEngine.Debug.Log($"{InMsg}\nList is empty.");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(InMsg).Append("\n");
                        sb.Append("[<").Append(0).Append(", ").Append(InList[0]).Append(">");
                        for (int i = 1; i < count; i++)
                        {
                            sb.Append(", <").Append(i).Append(", ").Append(InList[i]).Append(">");
                        }

                        sb.Append("]");
                        UnityEngine.Debug.Log(sb.ToString());
                    }
                }
            }
            else
            {
                string colorHex = ColorUtil.GetColorHex(InColorName);

                if (null == InList)
                {
                    UnityEngine.Debug.Log(
                        $"<color={colorHex}>{InMsg}</color>\n<color={colorHex}>List is null.</color>");
                }
                else
                {
                    int count = InList.Count;
                    if (0 == count)
                    {
                        UnityEngine.Debug.Log(
                            $"<color={colorHex}>{InMsg}</color>\n<color={colorHex}>List is empty.</color>");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<color=").Append(colorHex).Append(">").Append(InMsg).Append("</color>\n<color=")
                            .Append(colorHex).Append(">");
                        sb.Append("[<").Append(0).Append(", ").Append(InList[0]).Append(">");
                        for (int i = 1; i < count; i++)
                        {
                            sb.Append(", <").Append(i).Append(", ").Append(InList[i]).Append(">");
                        }

                        sb.Append("]").Append("</color>");
                        UnityEngine.Debug.Log(sb.ToString());
                    }
                }
            }
        }

        [Conditional("LOG_INFO")]
        public static void Info<T>(string InMsg, IEnumerable<T> InIEnumerator,
            ColorName InColorName = ColorName.Default,
            int InTag = 1)
        {
            if ((InTag & ShowTag) != InTag)
                return;

            if (InColorName == ColorName.Default)
            {
                if (null == InIEnumerator)
                {
                    UnityEngine.Debug.Log($"{InMsg}\nIEnumerator<T> is null.");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(InMsg).Append("\n");
                    using (IEnumerator<T> enumerator = InIEnumerator.GetEnumerator())
                    {
                        enumerator.MoveNext();
                        sb.Append("{<").Append(enumerator.Current).Append(">");
                        while (enumerator.MoveNext())
                        {
                            sb.Append(", <").Append(enumerator.Current).Append(">");
                        }
                    }

                    sb.Append("}");
                    UnityEngine.Debug.Log(sb);
                }
            }
            else
            {
                string colorHex = ColorUtil.GetColorHex(InColorName);
                if (null == InIEnumerator)
                {
                    UnityEngine.Debug.Log(
                        $"<color={colorHex}>{InMsg}</color>\n<color={colorHex}>IEnumerator<T> is null.</color>");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<color=").Append(colorHex).Append(">").Append(InMsg).Append("</color>\n<color=").Append(colorHex).Append(">");
                    using (IEnumerator<T> enumerator = InIEnumerator.GetEnumerator())
                    {
                        enumerator.MoveNext();
                        sb.Append("{<").Append(enumerator.Current).Append(">");
                        while (enumerator.MoveNext())
                        {
                            sb.Append(", <").Append(enumerator.Current).Append(">");
                        }
                    }
                    sb.Append("}").Append("</color>");
                    UnityEngine.Debug.Log(sb);
                }
            }
        }
        
        [Conditional("LOG_INFO")]
        public static void Info<TKey, TValue>(string InMsg, IEnumerable<KeyValuePair<TKey, TValue>> InIEnumerator,
            ColorName InColorName = ColorName.Default,
            int InTag = 1)
        {
            if ((InTag & ShowTag) != InTag)
                return;

            if (InColorName == ColorName.Default)
            {
                if (null == InIEnumerator)
                {
                    UnityEngine.Debug.Log($"{InMsg}\nIEnumerator<T> is null.");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(InMsg).Append("\n");
                    using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = InIEnumerator.GetEnumerator())
                    {
                        enumerator.MoveNext();
                        KeyValuePair<TKey, TValue> current = enumerator.Current;
                        sb.Append("{<").Append(current.Key).Append(", ").Append(current.Value).Append(">");
                        while (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            sb.Append(", <").Append(current.Key).Append(", ").Append(current.Value).Append(">");
                        }
                    }

                    sb.Append("}");
                    UnityEngine.Debug.Log(sb);
                }
            }
            else
            {
                string colorHex = ColorUtil.GetColorHex(InColorName);
                if (null == InIEnumerator)
                {
                    UnityEngine.Debug.Log(
                        $"<color={colorHex}>{InMsg}</color>\n<color={colorHex}>IEnumerator<T> is null.</color>");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<color=").Append(colorHex).Append(">").Append(InMsg).Append("</color>\n<color=").Append(colorHex).Append(">");
                    using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = InIEnumerator.GetEnumerator())
                    {
                        enumerator.MoveNext();
                        KeyValuePair<TKey, TValue> current = enumerator.Current;
                        sb.Append("{<").Append(current.Key).Append(", ").Append(current.Value).Append(">");
                        while (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            sb.Append(", <").Append(current.Key).Append(", ").Append(current.Value).Append(">");
                        }
                    }
                    sb.Append("}").Append("</color>");
                    UnityEngine.Debug.Log(sb);
                }
            }
        }


        [Conditional("LOG_WARNING")]
        public static void Warning(object InMsg)
        {
            UnityEngine.Debug.LogWarning(InMsg);
        }

        [Conditional("LOG_WARNING")]
        public static void Warning(object InMsg, UnityEngine.Object InContext)
        {
            UnityEngine.Debug.LogWarning(InMsg, InContext);
        }

        public static void Error(object InMsg)
        {
            UnityEngine.Debug.LogError(InMsg);
        }

        public static void Error(object InMsg, UnityEngine.Object InContext)
        {
            UnityEngine.Debug.LogError(InMsg, InContext);
        }

        public static void ErrorFormat(string InFormat, params object[] InArgs)
        {
            UnityEngine.Debug.LogErrorFormat(InFormat, InArgs);
        }

        public static void ErrorFormat(UnityEngine.Object InContext, string InFormat, params object[] InArgs)
        {
            UnityEngine.Debug.LogErrorFormat(InContext, InFormat, InArgs);
        }

        public static void Exception(Exception InException)
        {
            UnityEngine.Debug.LogException(InException);
        }

        public static void Exception(Exception InException, UnityEngine.Object InContext)
        {
            UnityEngine.Debug.LogException(InException, InContext);
        }
    }
}