namespace Target.SqlServer.Configurations
{
    public static class SqlServerBuilderTypes
    {
        public const string Guid = "UNIQUEIDENTIFIER";
        
        public const string ForeignKey = Guid;
        
        public const string DateTime = "DATETIME";
        
        public const string Text = "NTEXT";
        
        public const string LongText = "NTEXT";
        
        public const string UnsignedInt = "INT";
        
        public const string SignedInt = "INT";
        
        public const string Enum = "TINYINT";

        public static string String(int length, bool isFixedLength = false)
        {
            return isFixedLength ? $"NCHAR({length})" : $"NVARCHAR({length})";
        }
    }
}