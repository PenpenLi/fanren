using System;
using System.IO;
using UnityEngine;

namespace UnityUtility
{

	public class CSerializer
	{
		// Token: 0x0600355A RID: 13658 RVA: 0x0018671C File Offset: 0x0018491C
		public void BeginWrite()
		{
			MemoryStream output = new MemoryStream();
			BinaryWriter cWriterStream = new BinaryWriter(output);
			this.m_cWriterStream = cWriterStream;
		}

		// Token: 0x0600355B RID: 13659 RVA: 0x00020A81 File Offset: 0x0001EC81
		public void EndWrite()
		{
			if (this.m_cWriterStream == null)
			{
				return;
			}
			this.m_cWriterStream.Close();
		}

		// Token: 0x0600355C RID: 13660 RVA: 0x00186740 File Offset: 0x00184940
		public byte[] GetWriteBytes()
		{
			return (this.m_cWriterStream.BaseStream as MemoryStream).ToArray();
		}

		// Token: 0x0600355D RID: 13661 RVA: 0x00186764 File Offset: 0x00184964
		public void Write(Vector3 pos)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(pos.x);
			this.m_cWriterStream.Write(pos.y);
			this.m_cWriterStream.Write(pos.z);
		}

		// Token: 0x0600355E RID: 13662 RVA: 0x00020A9A File Offset: 0x0001EC9A
		public void Write(byte bt)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(bt);
		}

		// Token: 0x0600355F RID: 13663 RVA: 0x00020AC9 File Offset: 0x0001ECC9
		public void Write(int value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003560 RID: 13664 RVA: 0x00020AF8 File Offset: 0x0001ECF8
		public void Write(short value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003561 RID: 13665 RVA: 0x00020B27 File Offset: 0x0001ED27
		public void Write(float value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003562 RID: 13666 RVA: 0x00020B56 File Offset: 0x0001ED56
		public void Write(double value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003563 RID: 13667 RVA: 0x00020B85 File Offset: 0x0001ED85
		public void Write(bool value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003564 RID: 13668 RVA: 0x001867C8 File Offset: 0x001849C8
		public void Write(string value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value.Length);
			this.m_cWriterStream.Write(value.ToCharArray());
		}

		// Token: 0x06003565 RID: 13669 RVA: 0x00020BB4 File Offset: 0x0001EDB4
		public void Write(char value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003566 RID: 13670 RVA: 0x00020BE3 File Offset: 0x0001EDE3
		public void Write(char[] value)
		{
			if (this.m_cWriterStream == null || !this.m_cWriterStream.BaseStream.CanWrite)
			{
				return;
			}
			this.m_cWriterStream.Write(value.Length);
			this.m_cWriterStream.Write(value);
		}

		// Token: 0x06003567 RID: 13671 RVA: 0x00186818 File Offset: 0x00184A18
		public void BeginRead(byte[] data)
		{
			if (data == null)
			{
				return;
			}
			MemoryStream input = new MemoryStream(data);
			this.m_cReaderStream = new BinaryReader(input);
		}

		// Token: 0x06003568 RID: 13672 RVA: 0x00020C20 File Offset: 0x0001EE20
		public void EndRead()
		{
			if (this.m_cReaderStream == null)
			{
				return;
			}
			this.m_cReaderStream.Close();
		}

		// Token: 0x06003569 RID: 13673 RVA: 0x00186840 File Offset: 0x00184A40
		public Vector3 ReadVector3()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Float ReadStream.");
				return Vector3.zero;
			}
			float x = this.ReadFloat();
			float y = this.ReadFloat();
			float z = this.ReadFloat();
			return new Vector3(x, y, z);
		}

		// Token: 0x0600356A RID: 13674 RVA: 0x00020C39 File Offset: 0x0001EE39
		public byte ReadByte()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Float ReadStream.");
				return 0;
			}
			return this.m_cReaderStream.ReadByte();
		}

		// Token: 0x0600356B RID: 13675 RVA: 0x00020C72 File Offset: 0x0001EE72
		public float ReadFloat()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Float ReadStream.");
				return 0f;
			}
			return this.m_cReaderStream.ReadSingle();
		}

		// Token: 0x0600356C RID: 13676 RVA: 0x00020CAF File Offset: 0x0001EEAF
		public long ReadInt64()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Int ReadStream.");
				return 0L;
			}
			return this.m_cReaderStream.ReadInt64();
		}

		// Token: 0x0600356D RID: 13677 RVA: 0x00020CE9 File Offset: 0x0001EEE9
		public int ReadInt32()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Int ReadStream.");
				return 0;
			}
			return this.m_cReaderStream.ReadInt32();
		}

		// Token: 0x0600356E RID: 13678 RVA: 0x00020D22 File Offset: 0x0001EF22
		public short ReadInt16()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Int ReadStream.");
				return 0;
			}
			return this.m_cReaderStream.ReadInt16();
		}

		// Token: 0x0600356F RID: 13679 RVA: 0x00020D5B File Offset: 0x0001EF5B
		public char ReadChar()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Char ReadStream.");
				return 'E';
			}
			return this.m_cReaderStream.ReadChar();
		}

		// Token: 0x06003570 RID: 13680 RVA: 0x00020D95 File Offset: 0x0001EF95
		public bool ReadBool()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Bool ReadStream.");
				return false;
			}
			return this.m_cReaderStream.ReadBoolean();
		}

		// Token: 0x06003571 RID: 13681 RVA: 0x00020DCE File Offset: 0x0001EFCE
		public char[] ReadChars(int len)
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Chars ReadStream.");
				return null;
			}
			return this.m_cReaderStream.ReadChars(len);
		}

		// Token: 0x06003572 RID: 13682 RVA: 0x0018689C File Offset: 0x00184A9C
		public char[] ReadChars()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in Chars ReadStream.");
				return null;
			}
			int count = this.ReadInt32();
			return this.m_cReaderStream.ReadChars(count);
		}

		// Token: 0x06003573 RID: 13683 RVA: 0x00020E08 File Offset: 0x0001F008
		public string ReadStr(int len)
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in String ReadStream.");
				return null;
			}
			return new string(this.m_cReaderStream.ReadChars(len));
		}

		// Token: 0x06003574 RID: 13684 RVA: 0x001868E8 File Offset: 0x00184AE8
		public string ReadStr()
		{
			if (this.m_cReaderStream == null || !this.m_cReaderStream.BaseStream.CanRead)
			{
				Debug.LogError("There is something in String ReadStream.");
				return null;
			}
			int count = this.ReadInt32();
			char[] value = this.m_cReaderStream.ReadChars(count);
			return new string(value);
		}

		// Token: 0x04003C7F RID: 15487
		private BinaryWriter m_cWriterStream;

		// Token: 0x04003C80 RID: 15488
		private BinaryReader m_cReaderStream;
	}
}
