using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;

namespace LibSftp
{
    /// <summary>
    /// SFTP経由でファイルダウンロードを行うだけのクラス
    /// </summary>
    public class FileDownloader
    {
        /// <summary>
        /// ファイルをダウンロードする
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        public void Download(string remotePath, string localPath, ConnectionInfo connectionInfo)
        {
            using (var client = new SftpClient(connectionInfo))
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
    }
}
