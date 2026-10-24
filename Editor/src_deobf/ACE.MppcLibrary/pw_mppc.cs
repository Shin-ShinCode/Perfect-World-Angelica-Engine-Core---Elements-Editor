namespace ACE.MppcLibrary;

public interface pw_mppc
{
	byte[] compress(byte[] buffer);

	byte[] decompress(byte[] buffer, int dataSize);
}
