namespace ACE.Dependency.zlibnet.Minizip;

internal struct ZipEntryInfo64
{
	public uint Version;

	public uint VersionNeeded;

	public uint Flag;

	public uint CompressionMethod;

	public uint DosDate;

	public uint Crc;

	public ulong CompressedSize;

	public ulong UncompressedSize;

	public uint FileNameLength;

	public uint ExtraFieldLength;

	public uint CommentLength;

	public uint DiskStartNumber;

	public uint InternalFileAttributes;

	public uint ExternalFileAttributes;

	public ZipDateTimeInfo ZipDateTime;
}
