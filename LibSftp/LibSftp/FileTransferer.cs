using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;

namespace LibSftp
{
    /// <summary>
    /// SFTP経由でファイルダウンロード/アップロードを行うクラス
    /// </summary>
    public class FileTransferer
    {
        /// <summary>
        /// FileTransfererの新しいインスタンスを作成します
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static FileTransferer Create(string host, int port, string username, string password)
        {
            var method = new PasswordAuthenticationMethod(username, password);
            var info = new ConnectionInfo(host, port, username, method);
            return new FileTransferer(info);
        }

        private ConnectionInfo ConnectionInfo { get; set; }

        public FileTransferer(ConnectionInfo conn)
        {
            this.ConnectionInfo = conn;
        }
        
        /// <summary>
        /// ファイルをダウンロードする
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        public void Download(string remotePath, string localPath)
        {
            using (var client = new SftpClient(this.ConnectionInfo))
            {
                client.Connect();
                using (var fs = System.IO.File.OpenWrite(localPath))
                {
                    client.DownloadFile(remotePath, fs, _ => { });
                }
            }
        }

        /// <summary>
        /// ファイルをアップロードする
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        public void Upload(string localPath, string remotePath)
        {
            using (var client = new SftpClient(this.ConnectionInfo))
            {
                client.Connect();
                using (var fs = System.IO.File.OpenRead(localPath))
                {
                    client.UploadFile(fs, remotePath, true, null);
                }
            }
        }
    }
}
