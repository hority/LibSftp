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
        /// 接続の情報
        /// </summary>
        private ConnectionInfo ConnectionInfo { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="conn"></param>
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
                // 書き込みモードでローカルファイルを開く(なければ作成、あれば上書き)
                using (var fs = System.IO.File.OpenWrite(localPath))
                {
                    client.DownloadFile(remotePath, fs, null);
                }
                client.Disconnect();
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
                // 書き込みモードでローカルファイルを開く
                using (var fs = System.IO.File.OpenRead(localPath))
                {
                    client.UploadFile(fs, remotePath, true, null);
                }
                client.Disconnect();
            }
        }
    }
}
