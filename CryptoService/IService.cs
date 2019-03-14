using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CryptoService
{
    [ServiceContract]
    public interface IService
    {
        // Funkcije za MiniCloud 
        [OperationContract]
        Stream DownloadFile(string name);

        [OperationContract]
        UploadFileResponse UploadFile(FileUploadMessage file);

        [OperationContract]
        List<string> ListFiles();

        [OperationContract]
        bool DeleteFile(string filename);

        [OperationContract]
        byte[] EncryptText(EncryptTextMessage message);
        [OperationContract]
        byte[] DecryptText(EncryptTextMessage message);

        // Funkcije za Cypher komponentu
        // treba da napravim funkciju koja ce da encriptuje i dekriptuje fajl
        // mora da primi stream, ime fajla, algoritam kojim se kriptuje i propertije
        // koji su potrebni algoritmu pri kriptovanju
        [OperationContract]
        EncryptFileResponse Encrypt(EncryptFileMessage cryptMessage);
        [OperationContract]
        EncryptFileResponse Decrypt(EncryptFileMessage decryptMessage);

    }


    #region Contracts

    #region MiniCloud
    /// <summary>
    /// Koristim MessageContract za stream kako bih mogao da 
    /// prosledim neke dodatne podatke, jer moze samo 1 argument
    /// Ne moze primitivni i slozen tip podataka u isto vreme
    /// Vec mora da se wrappuje
    /// </summary>
    [MessageContract]
    public class FileUploadMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public FileMetaData Metadata { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream Data { get; set; }
    }

    [DataContract]
    public class FileMetaData
    {
        [DataMember(Name = "fileName", Order = 0, IsRequired = false)]
        public string fileName;
    }

    // Response MessageContract
    [MessageContract]
    public class UploadFileResponse
    {
        [MessageBodyMember(Order = 1)]
        public bool Finished { get; set; }
    }

    [MessageContract]
    public class EncryptFileResponse
    {
        [MessageBodyMember(Order = 1)]
        public bool Finished { get; set; }
        //public Stream EncryptedData { get; set; }
    }
    #endregion

    #region Kriptovanje

    // Kojim algoritmom ce se kriptovati
    public enum AlgorithmType
    {
        RC4,
        RC4CTR,
        A52,
        A52CTR,
        RSA,
        TigerHash
    };

    // Enkriptovanje

    [DataContract]
    public class AlgorithmProperties
    {
        [DataMember(Name = "FileName", Order = 0)]
        public string FileName;

        [DataMember(Name = "Key", Order = 1)]
        public byte[] Key { get; set; }

        [DataMember(Name = "IV", Order = 2)]
        public byte[] IV { get; set; }

        [DataMember(Name = "AlgorithmType", Order = 3)]
        public AlgorithmType AlgorithmType { get; set; }

        [DataMember(Name = "FKeyA52", Order = 4)]
        public string FKeyA52 { get; set; }

        [DataMember(Name = "P", Order = 5)]
        public byte[] P { get; set; }

        [DataMember(Name = "Q", Order = 6)]
        public byte[] Q { get; set; }
    }

    [MessageContract]
    public class EncryptFileMessage
    {
        [MessageHeader(Name = "MetaData", MustUnderstand = true)]
        public AlgorithmProperties MetaData { get; set; }

        [MessageBodyMember(Name = "Data", Order = 4)]
        public Stream Data { get; set; }
    }

    [DataContract]
    public class EncryptTextMessage
    {
        [DataMember]
        public byte[] Data { get; set; }
        [DataMember]
        public byte[] Key { get; set; }
        [DataMember]
        public byte[] IV { get; set; }
        [DataMember]
        public AlgorithmType Algorithm { get; set; }
        [DataMember]
        public string FKeyA52 { get; set; }
        [DataMember]
        public byte[] P { get; set; }
        [DataMember]
        public byte[] Q { get; set; }
    }
    #endregion

    #endregion
}
