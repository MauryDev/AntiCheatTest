using System;

using System.Runtime.InteropServices;

namespace AntiCheat
{
        public class ObscuredInt
        {
            [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr Obscured_RandomKey(int size);
            [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern IntPtr ObscuredInt_New(int value, [MarshalAs(UnmanagedType.LPStr)]string password);
            [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern int ObscuredInt_SetValue(IntPtr address, int value);
            [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern int ObscuredInt_GetValue(IntPtr address);
            [return: MarshalAs(UnmanagedType.U1)]
            [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern bool ObscuredInt_IsValidChanged(IntPtr address);
            [DllImport("Test.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern void ObscuredInt_OnCheatDetected([MarshalAs(UnmanagedType.FunctionPtr)] Delegate address);
            public IntPtr M_PTR;
            public ObscuredInt(int value, string key)
            {
                M_PTR = ObscuredInt_New(value, key);
            }
            public bool IsValidChanged()
            {
                return ObscuredInt_IsValidChanged(M_PTR);
            }
            public static string RandomKey(int len)
            {
                return Marshal.PtrToStringAnsi(Obscured_RandomKey(len));
            }
            public static void OnCheatDetected(Action e)
            {
                ObscuredInt_OnCheatDetected(e);
            }
            public int Value
            {
                get
                {
                    return ObscuredInt_GetValue(M_PTR);
                }
                set
                {
                    ObscuredInt_SetValue(M_PTR,value);
                }
            }
            public static implicit operator ObscuredInt(int value)
            {
                return new ObscuredInt(value, RandomKey(6));
            }
            public static implicit operator int(ObscuredInt value)
            {
                return value.Value;
            }
            public static ObscuredInt operator ++(ObscuredInt input)
            {
                input.Value += 1;
                return input;
            }
            public static ObscuredInt operator --(ObscuredInt input)
            {
                input.Value -= 1;
                return input;
            }
            public override bool Equals(object obj)
            {
                return obj is ObscuredInt && this.Equals((ObscuredInt)obj);
            }
            public bool Equals(ObscuredInt obj)
            {

                return obj.Value == this.Value;
            }
            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }
            public override string ToString()
            {
                return this.Value.ToString();
            }
            public string ToString(IFormatProvider provider)
            {
                return this.Value.ToString(provider);
            }
            public string ToString(string format, IFormatProvider provider)
            {
                return this.Value.ToString(format, provider);
            }

        }
}
