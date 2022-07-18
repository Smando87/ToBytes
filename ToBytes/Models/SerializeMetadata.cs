namespace ToBytes
{
    public class SerializeMetadata
    {
        public long MetaDataLength { get; set; }
        public long DataLength { get; set; }
        public long Length { get; set; }
        public long DataOffset { get; set; }
        public byte[] Data { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(MetaDataLength)}: {MetaDataLength}, {nameof(DataLength)}: {DataLength}, {nameof(Length)}: {Length}, {nameof(DataOffset)}: {DataOffset}";
        }
    }
}