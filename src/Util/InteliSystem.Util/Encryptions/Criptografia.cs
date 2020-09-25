using System;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;

namespace InteliSystem.Util.Encryptions
{
    public class Criptografia
    {
        #region Membros
		private static TripleDES des;
		private string schave = "";
		private string siv = "";
		private byte[] chave;
		private byte[] iv;
		#endregion

		#region Construtores
		/// <summary>
		/// Construtor
		/// </summary>
		public Criptografia()
		{
			des = new TripleDESCryptoServiceProvider();
			chave = Encoding.UTF8.GetBytes("KUgygTR$6@¨%@8Wj18&98(#(");
			iv = Encoding.UTF8.GetBytes("(&eq15H*");
			des.Key = chave;
			des.IV = iv;
		}
		/// <summary>
		/// Construtor
		/// </summary>
		/// <param name="mode">Modo de Criptografia</param>
		public Criptografia(CipherMode mode)
			: this()
		{

			des.Mode = mode;
		}
		public Criptografia(string chave)
			: this()
		{
			des.Key = Encoding.UTF8.GetBytes(chave);
		}
		/// <summary>
		/// Construtor
		/// </summary>
		/// <param name="chave">Chave com Tamanho de 24 Bytes Exatos</param>
		/// <param name="iv">IV com Tanho de 8 Bytes Exatos</param>
		public Criptografia(string chave, string iv)
			: this()
		{
			des.Key = Encoding.UTF8.GetBytes(chave);
			des.IV = Encoding.UTF8.GetBytes(iv);
		}
		/// <summary>
		/// Construtor
		/// </summary>
		/// <param name="chave">Chave com Tamanho de 24 Bytes Exatos</param>
		/// <param name="iv">IV com Tanho de 8 Bytes Exatos</param>
		/// <param name="mode">Modo de Criptografria</param>
		public Criptografia(string chave, string iv, CipherMode mode)
			: this(mode)
		{
			des.Key = Encoding.UTF8.GetBytes(chave);
			des.IV = Encoding.UTF8.GetBytes(iv);
		}
		#endregion

		#region Propriedades
		public string Chave
		{
			internal get {
				return schave;
			}
			set {
				schave = value;
			}
		}

		public string IV
		{
			internal get {
				return siv;
			}
			set {
				siv = value;
			}
		}

		#endregion

		#region Métodos
		/// <summary>
		/// Criptografia de Valores
		/// </summary>
		/// <param name="valor">Valor a ser Criptografado</param>
		/// <returns></returns>
		public string Encriptar(string valor)
		{
			byte[] buffer;
			var texto = new MemoryStream();

			try {
				if (des == null) {
					des = new TripleDESCryptoServiceProvider();
					des.Key = chave;
					des.IV = iv;
				}

				if (!string.IsNullOrEmpty(Chave)) {
					des.Key = Encoding.UTF8.GetBytes(Chave);
				}

				if (!string.IsNullOrEmpty(IV)) {
					des.IV = Encoding.UTF8.GetBytes(IV);
				}

				var servico = des.CreateEncryptor();
				buffer = Encoding.UTF8.GetBytes(valor);
				var stream = new CryptoStream(texto, servico, CryptoStreamMode.Write);
				stream.Write(buffer, 0, buffer.Length);
				stream.FlushFinalBlock();
				stream.Close();
				return Convert.ToBase64String(texto.ToArray());
			} catch (Exception) {
				throw;
			}
		}

		/// <summary>
		/// Descriptografia de Valores
		/// </summary>
		/// <param name="valor">Valor a ser Descriptografado</param>
		/// <returns></returns>
		public string Desencriptar(string valor)
		{
			byte[] buffer;
			var texto = new MemoryStream();
			try {
				if (des == null) {
					des = new TripleDESCryptoServiceProvider();
					des.Key = chave;
					des.IV = iv;
				}

				if (!string.IsNullOrEmpty(Chave)) {
					des.Key = Encoding.UTF8.GetBytes(Chave);
				}

				if (!string.IsNullOrEmpty(IV)) {
					des.IV = Encoding.UTF8.GetBytes(IV);
				}

				var servico = des.CreateDecryptor();
				buffer = Convert.FromBase64String(valor);
				var stream = new CryptoStream(texto, servico, CryptoStreamMode.Write);
				stream.Write(buffer, 0, buffer.Length);
				stream.Close();
				return Encoding.UTF8.GetString(texto.ToArray());
			} catch (Exception) {
				throw;
			}
		}

		public static string GerarSenha(int tamanho = 20)
		{
			// Numero de digitos da senha
			string senha = string.Empty;
			int qtdChar = 0;
			Random random = new Random();
			for (int i = 0; i < tamanho; i++) {
				int codigo = random.Next(48, 122);

				if ((codigo >= 48 && codigo <= 57 && !string.IsNullOrEmpty(senha)) || (codigo >= 65 && codigo <= 90) || (codigo >= 97 && codigo <= 122)) {
					string _char = ((char)codigo).ToString();
					if (!senha.Contains(_char)) {
						senha += _char;
					} else {
						foreach (var item in senha) {
							if (item.Equals(_char)) {
								qtdChar++;
							}
						}
						if (qtdChar < 3) {
							senha += _char;
						} else {
							i--;
						}
					}
				} else {
					i--;
				}
			}
			return senha;
		}

		public static string GerarChave(string ibase = "", short tamanho = 24)
		{
			
			var bytes = Encoding.UTF8.GetBytes("&%#45687@!#14+4");
			if (!string.IsNullOrEmpty(ibase)) {
				bytes = Encoding.UTF8.GetBytes(ibase);
			}
			string chave = "";

			for (int i = 0; i <= tamanho; i++) {
				if (i < bytes.Length) {
					chave += bytes[i].ToString("X2");
					continue;
				}
				if (chave.Length >= tamanho) {
					if (chave.Length == tamanho) {
						break;
					}
					chave = chave.Substring(0, tamanho);
					break;
				}
				chave += Byte.Parse(i.ToString()).ToString("X2");
			}
			
			return chave;
		}

		public String DesencriptarHexadecimal(string value)
		{
			try {

				var criptografia = HexaToTexto(value);

				var texto = Desencriptar(criptografia);

				return texto;

			} catch (Exception) {
				throw;
			}
		}

		public String EncriptarHexadecimal(string value)
		{
			try {

				var criptografia = Encriptar(value);

				return TextoToHexa(criptografia);

			} catch (Exception) {
				throw;
			}
		}

		public static string EncriptarMD5(string value)
		{
			try {
				var md5 = MD5.Create();
				var arAux = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
				var hashBuild = new StringBuilder();
				for (int i = 0; i < arAux.Length; i++) {
					hashBuild.Append(arAux[i].ToString("x2"));
				}

				return hashBuild.ToString();
			} catch (Exception) {
				throw;
			}
		}

		private string TextoToHexa(string value)
		{
			try {
				var bytes = Encoding.UTF8.GetBytes(value);

				var hexa = BitConverter.ToString(bytes).Replace("-", "");
				return hexa;
			} catch (Exception) {
				throw;
			}
		}

		private string HexaToTexto(string value)
		{
			try {


				var campos = new byte[value.Length / 2];

				for (int i = 0; i < campos.Length; i++) {

					campos[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
				}

				return Encoding.ASCII.GetString(campos);

			} catch (Exception) {
				throw;
			}
		}

		private byte[] HexaToByte(string value)
		{
			var campos = new byte[value.Length / 2];
			for (int i = 0; i < campos.Length; i++)
			{
				campos[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
			}
			return campos;
		}

		public string ToHash(string value)
		{
			HMACSHA512 hash = new HMACSHA512();
			var retorno = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

			return TextoToHexa(Convert.ToBase64String(retorno));
		}


		/// <summary>
		/// Dispose
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (des == null || !disposing) {
				return;
			}
			des.Dispose();
			des = null;
		}

		#endregion
    }
}