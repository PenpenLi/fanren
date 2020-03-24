using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/// <summary>
/// 数据加密
/// </summary>
public sealed class DES
{
    private string iv = "EWSSSNVDCDCX";

    private string key = "DERYTXCV";

    public string IV
	{
		get
		{
			return this.iv;
		}
		set
		{
			this.iv = value;
		}
	}

	public string Key
	{
		get
		{
			return this.key;
		}
		set
		{
			this.key = value;
		}
	}

	public string Encrypt(string sourceString)
	{
		byte[] bytes = Encoding.Default.GetBytes(this.key);
		byte[] bytes2 = Encoding.Default.GetBytes(this.iv);
		DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
		string result;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			byte[] bytes3 = Encoding.Default.GetBytes(sourceString);
			try
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(bytes, bytes2), CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes3, 0, bytes3.Length);
					cryptoStream.FlushFinalBlock();
				}
				result = Convert.ToBase64String(memoryStream.ToArray());
			}
			catch
			{
				throw;
			}
		}
		return result;
	}

	public string Decrypt(string encryptedString)
	{
		byte[] bytes = Encoding.Default.GetBytes(this.key);
		byte[] bytes2 = Encoding.Default.GetBytes(this.iv);
		DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
		string @string;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			byte[] array = Convert.FromBase64String(encryptedString);
			try
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateDecryptor(bytes, bytes2), CryptoStreamMode.Write))
				{
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
				}
				@string = Encoding.Default.GetString(memoryStream.ToArray());
			}
			catch
			{
				throw;
			}
		}
		return @string;
	}

	public void EncryptFile(string sourceFile, string destFile)
	{
		if (!File.Exists(sourceFile))
		{
			throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);
		}
		byte[] bytes = Encoding.Default.GetBytes(this.key);
		byte[] bytes2 = Encoding.Default.GetBytes(this.iv);
		DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
		byte[] array = File.ReadAllBytes(sourceFile);
		using (FileStream fileStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
		{
			try
			{
				using (CryptoStream cryptoStream = new CryptoStream(fileStream, descryptoServiceProvider.CreateEncryptor(bytes, bytes2), CryptoStreamMode.Write))
				{
					cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				fileStream.Close();
			}
		}
	}

	public void EncryptFile(string sourceFile)
	{
		this.EncryptFile(sourceFile, sourceFile);
	}

    /// <summary>
    /// 解密文件
    /// </summary>
    /// <param name="sourceFile"></param>
    /// <param name="destFile"></param>
	public void DecryptFile(string sourceFile, string destFile)
	{
		if (!File.Exists(sourceFile))
		{
            throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);
		}
        byte[] bytes = Encoding.Default.GetBytes(this.key);
		byte[] bytes2 = Encoding.Default.GetBytes(this.iv);
        DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
        byte[] array = File.ReadAllBytes(sourceFile);
        using (FileStream fileStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
		{
			try
			{
                using (CryptoStream cryptoStream = new CryptoStream(fileStream, descryptoServiceProvider.CreateDecryptor(bytes, bytes2), CryptoStreamMode.Write))
				{
                    cryptoStream.Write(array, 0, array.Length);
					cryptoStream.FlushFinalBlock();
				}
			}
			catch
			{
                throw;
			}
			finally
			{
                fileStream.Close();
			}
		}
	}

	public void DecryptFile(string sourceFile)
	{
		this.DecryptFile(sourceFile, sourceFile);
	}
}
