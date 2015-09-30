using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToTreeLib
{
    public enum SymbolType
    {
        BY_TYPE,
        BY_VALUE,
        BY_SYMBOL
    }

    public enum TrackStatus
    {
        PENDING,
        MATCHED,
        FAILED
    }

    public class SymbolLineDefinitionItem
    {
        public SymbolType type;
        public string text;
        public UInt32 min = 1;
        public UInt32 max = 1;
    }
}
