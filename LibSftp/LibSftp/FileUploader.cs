using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;

namespace LibSftp
{
    /// <summary>
    /// SFTP経由でファイルアップロードを行うだけのクラス
    /// </summary>
    public class FileUploader
    {
        /// <summary>
        /// ファイルをアップロードする
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        public void Upload(string localPath, string remotePath, ConnectionInfo connectionInfo)
        {
            using (var client = new SftpClient(connectionInfo))
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
