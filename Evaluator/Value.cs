namespace Evaluator
{
    public class Value
    {
        public readonly object value;

        public Value(object value)
        {
            this.value = value;
        }

        public bool IsDouble()
        {
            return this.value is double;
        }

        public bool IsBool()
        {
            return this.value is bool;
        }

        public bool IsString()
        {
            return this.value is string;
        }

        public bool TryGetDouble(out double doubleValue)
        {
            if (this.IsDouble())
            {
                doubleValue = (double)this.value;
                return true;
            }

            if (this.IsBool())
            {
                doubleValue = (bool)this.value ? 1 : 0;
                return true;
            }

            doubleValue = 0;
            return false;
        }

        public bool TryGetBool(out bool boolValue)
        {
            if (this.IsBool())
            {
                boolValue = (bool)this.value;
                return true;
            }

            boolValue = false;
            return false;
        }

        public bool TryGetString(out string stringValue)
        {
            if (this.IsString())
            {
                stringValue = (string)this.value;
                return true;
            }

            stringValue = string.Empty;
            return false;
        }
    }
}