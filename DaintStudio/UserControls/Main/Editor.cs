
using DaintStudio.Forms;
using DaintStudio.Models;
using DaintStudio.Services.Common;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;

namespace DaintStudio.UserControls
{
    public partial class Editor : UserControl
    {
        private string rootFolder = StaticData.RootDrive;

        private string selectedFilePath = string.Empty;

        private static readonly HttpClient httpClient = new HttpClient();

        private async Task<string> GetDataFromApiAsync(string url)
        {
            try
            {
                // Gửi request GET
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Kiểm tra status code
                response.EnsureSuccessStatusCode();

                // Đọc nội dung trả về
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                // Xử lý lỗi mạng hoặc lỗi HTTP
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}");
                return null;
            }
        }

        private async Task<string> PostDataToApiAsync(string url, string jsonContent)
        {
            try
            {
                // Tạo nội dung JSON
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Gửi request POST
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                // Kiểm tra status code
                response.EnsureSuccessStatusCode();

                // Đọc nội dung trả về
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                // Xử lý lỗi mạng hoặc lỗi HTTP
                MessageBox.Show($"Lỗi khi gọi API: {ex.Message}");
                return null;
            }
        }

        public async Task<string> UploadFileAsync(string url, object file)
        {
            string serverUrl = url;

            try
            {
                HttpContent content;

                if (file is string strFile)
                {
                    // Nếu file là string
                    content = new StringContent(strFile, Encoding.UTF8, "text/plain");
                }
                else if (file is byte[] byteFile)
                {
                    // Nếu file là mảng byte
                    content = new ByteArrayContent(byteFile);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                }
                else
                {
                    throw new ArgumentException("File phải là string hoặc byte[]");
                }

                HttpResponseMessage response = await httpClient.PostAsync(serverUrl, content);

                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Upload failed: " + ex.Message);
                throw;
            }
        }

        public Editor()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Dark_Mode();

            init_tree_file(rootFolder);
        }
        
        private void Dark_Mode()
        {

            DarkTheme.Apply(this);

            this.BackColor = Color.FromArgb(30, 30, 30);

            this.ForeColor = Color.White;

        }

        private void init_tree_file(string rootFolder)
        {
            ImageList imageList = new ImageList();

            imageList.ImageSize = new Size(16, 16);

            imageList.Images.Add(Image.FromFile(Path.Combine(StaticData.RootDrive, "my_git", "assets", "image_png", "folder_icon.png"))); // index 0

            imageList.Images.Add(Image.FromFile(Path.Combine(StaticData.RootDrive, "my_git", "assets", "image_png", "file_icon.png")));   // index 1

            treeView.ImageList = imageList;

            treeView.Nodes.Clear();

            string[] files = Directory.GetFiles(rootFolder);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                TreeNode node = new TreeNode(fileInfo.Name);

                treeView.Nodes.Add(node);
            }

            string[] folders = Directory.GetDirectories(rootFolder);

            foreach (var folder in folders)
            {

                if (folder == Path.Combine(StaticData.RootDrive, "$RECYCLE.BIN") || folder == Path.Combine(StaticData.RootDrive, "System Volume Information"))
                {

                }
                else
                {

                    var folderInfo = new DirectoryInfo(folder);

                    TreeNode node = new TreeNode(folderInfo.Name);

                    treeView.Nodes.Add(node);

                    recurse(folderInfo.FullName, node);

                }

            }

        }

        private void tao_file_event(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                TextInputDialog textInputDialog = new TextInputDialog();

                DialogResult result = textInputDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string newNodeName = textInputDialog.UserInput;

                    TreeNode newNode = new TreeNode(newNodeName, 1, 1);

                    var fullPath = tim_full_path(treeView.SelectedNode);

                    var newFilePath = Path.Combine(fullPath, newNodeName);

                    File.Create(newFilePath).Close();

                    treeView.SelectedNode.Nodes.Add(newNode);

                    treeView.SelectedNode.Expand();

                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Người dùng nhấn Cancel");
                }

            }
        }

        private void tao_folder_event(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                TextInputDialog textInputDialog = new TextInputDialog();

                DialogResult result = textInputDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string newNodeFolderName = textInputDialog.UserInput;

                    var fullPath = tim_full_path(treeView.SelectedNode);

                    var newFolderPath = Path.Combine(fullPath, newNodeFolderName);

                    Directory.CreateDirectory(newFolderPath);

                    TreeNode newFolderNode = new TreeNode(newNodeFolderName, 0, 0);

                    treeView.SelectedNode.Nodes.Add(newFolderNode);

                    treeView.SelectedNode.Expand();

                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Người dùng nhấn Cancel");
                }
            }
        }

        private void delete_event(object sender, EventArgs e)
        {
            if (treeView.SelectedNode != null)
            {
                var fullPath = tim_full_path(treeView.SelectedNode);

                if (treeView.SelectedNode.ImageIndex == 0)
                {
                    Directory.Delete(fullPath, true);

                }
                else if (treeView.SelectedNode.ImageIndex == 1)
                {
                    File.Delete(fullPath);
                }
                init_tree_file(rootFolder);
            }
        }

        private string tim_full_path(TreeNode node)
        {
            string path = node.Text;
            TreeNode currentNode = node;
            while (currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                path = currentNode.Text + "/" + path;
            }
            return rootFolder + "/" + path;
        }

        private void before_expand(object sender, TreeViewCancelEventArgs e)
        {
            var nodes = e.Node?.Nodes;

            foreach (TreeNode node in nodes!)
            {
                if (node.ImageIndex == 0)
                {
                    recurse(tim_full_path(node), node);
                }
            }


        }

        private void recurse(string folderPath, TreeNode parentNode)
        {
            string[] files = Directory.GetFiles(folderPath);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                TreeNode node = new TreeNode(fileInfo.Name, 1, 1);
                parentNode.Nodes.Add(node);
            }
            string[] folders = Directory.GetDirectories(folderPath);
            foreach (var folder in folders)
            {
                var folderInfo = new DirectoryInfo(folder);
                TreeNode node = new TreeNode(folderInfo.Name, 0, 0);
                parentNode.Nodes.Add(node);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                treeView.SelectedNode = e.Node;

                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(treeView, e.Location);

                    contextMenuStrip1.Items.Clear();

                    if (e.Node?.ImageIndex == 1)
                    {
                        contextMenuStrip1.Items.Add("Xóa");

                        contextMenuStrip1.Items[0].Click += delete_event;

                        contextMenuStrip1.Items.Add("Chạy");

                        contextMenuStrip1.Items[1].Click += run_file;

                        contextMenuStrip1.Items.Add("Chạy cùng tham số");

                        contextMenuStrip1.Items[2].Click += run_file_with_param;
                    }
                    else
                    {
                        contextMenuStrip1.Items.Add("Tạo File");

                        contextMenuStrip1.Items[0].Click += tao_file_event;

                        contextMenuStrip1.Items.Add("Tạo Folder");

                        contextMenuStrip1.Items[1].Click += tao_folder_event;

                        contextMenuStrip1.Items.Add("Xóa");

                        contextMenuStrip1.Items[2].Click += delete_event;

                        contextMenuStrip1.Items.Add("Xem Thông tin");

                        contextMenuStrip1.Items[3].Click += get_info;

                        contextMenuStrip1.Items.Add("Push My Git");

                        contextMenuStrip1.Items[4].Click += push_my_git;

                        contextMenuStrip1.Items.Add("Pull My Git");

                        contextMenuStrip1.Items[5].Click += pull_my_git;
                    }



                }
                else if (e.Button == MouseButtons.Left && e.Node?.ImageIndex == 1)
                {
                    selectedFilePath = tim_full_path(e.Node);

                    var file = new FileInfo(selectedFilePath);

                    var extensionDisable = new List<string>()
                    {
                        ".png",
                        "jpg",
                        ".mp3",
                        ".mp4",
                        ".ico",
                        ".iso",
                        ".exe",
                        ".wav",
                        ".zip"
                    };

                    if (extensionDisable.Contains(file.Extension))
                    {
                        richTextBox.Text = "Không thể mở";

                    }
                    else
                    {
                        richTextBox.Text = File.ReadAllText(selectedFilePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void get_info(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(rootFolder, "ApiGateway", "data", "config", "main.json");

                MessageBox.Show(File.ReadAllText(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void push_my_git(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var path = tim_full_path(treeView.SelectedNode!);

                var folder_my_git = Path.Combine(path, ".my_git");

                if (!Directory.Exists(folder_my_git))
                {
                    TextInputDialog textInputDialog = new TextInputDialog();

                    DialogResult result = textInputDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string responseText = textInputDialog.UserInput;

                        Directory.CreateDirectory(folder_my_git);

                        var pathConfig = Path.Combine(rootFolder, "ApiGateway", "data", "config", "main.json");

                        var configValue = FileHelper.Read<MainConfig>(pathConfig);

                        var newConfigMyGit = new MyGitConfig()
                        {
                            server_ip = configValue.my_git_server_ip,
                            repository_name = responseText
                        };

                        FileHelper.Write(Path.Combine(folder_my_git, "config.json"), newConfigMyGit);

                        init_tree_file(rootFolder);

                        _ = await PostDataToApiAsync($"http://{newConfigMyGit.server_ip}:1704/file/add", JsonService.ToJson(new
                        {
                            label = responseText,
                            parentKey = "/var/lib/ApiGateway/my_git",
                            type ="folder"
                        }));

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("Người dùng nhấn Cancel");
                    }
                }

                var configMyGitValue = FileHelper.Read<MyGitConfig>(Path.Combine(folder_my_git, "config.json"));

                // kiểm tra trên server đã có repository chưa?
                // nếu chưa có thì báo lỗi, cần xóa repository cũ và tạo lại.
                // nếu có rồi thì làm theo các bước sau:
                // bước 1: nén cả folder vào 1 file zip
                // bước 2: delete fil zip cũ trên server
                // bước 3: đẩy file zip lên server
                // bước 4: xóa file zip cũ trên client

                var repositoriesString = await GetDataFromApiAsync($"http://{configMyGitValue.server_ip}:1704/file/scan?filepath=%2Fvar%2Flib%2FApiGateway%2Fmy_git");

                var repositories = JsonService.FromJson<ResponseModel<List<FileScanModel>>>(repositoriesString);

                bool isExistServer = false;

                foreach (var item in repositories?.data!)
                {
                    if(item.parentKey == "/var/lib/ApiGateway/my_git" && item.type == "folder")
                    {
                        if(configMyGitValue.repository_name == item.label)
                        {
                            // đã có trên server
                            isExistServer = true;
                            break;
                        }
                    }
                }

                if(isExistServer)
                {
                    //bước 1: nén cả folder vào 1 file zip
                    string startPath = path;

                    string zipPath = Path.Combine(rootFolder, "my_git", configMyGitValue.repository_name + ".zip");

                    var directory = Path.GetDirectoryName(zipPath);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory!);
                    }

                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }
                    ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Optimal, false);

                    // bước 2: delete fil zip cũ trên server

                    _ = await PostDataToApiAsync($"http://{configMyGitValue.server_ip}:1704/file/delete", JsonService.ToJson(new
                    {
                        label = configMyGitValue.repository_name + ".zip",
                        parentKey = "/var/lib/ApiGateway/my_git",
                        type = "folder"
                    }));

                    // bước 3: đẩy file zip lên server
                    var endpointPush = $"http://{configMyGitValue.server_ip}:1704/file/upload?filepath=%2Fvar%2Flib%2FApiGateway%2Fmy_git%2F{configMyGitValue.repository_name}&filename=" + configMyGitValue.repository_name + ".zip";

                    var bytesData = FileHelper.ReadFileAsBytes(zipPath);

                    _ = await UploadFileAsync(endpointPush, bytesData);

                    // bước 4: xóa file zip cũ trên client
                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }

                }
                else
                {
                    MessageBox.Show("Chưa có trên Server");
                }

                Cursor = Cursors.Default;

                MessageBox.Show("Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void pull_my_git(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                TextInputDialog textInputDialog = new TextInputDialog();

                DialogResult result = textInputDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string responseText = textInputDialog.UserInput;



                }
                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Người dùng nhấn Cancel");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor = Cursors.Default;

            MessageBox.Show("Thành công");
        }
        private void run_file(object sender, EventArgs e)
        {

        }
        private void run_file_with_param(object sender, EventArgs e)
        {

        }
        private async void buttonRun_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string scriptPath = selectedFilePath;

                //string argParam = "FLOW";

                //string arg = $"{argParam}-USDT";

                var psi = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"\"{scriptPath}\"", // $"\"{scriptPath}\" {arg}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();

                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(error))
                        MessageBox.Show(error);
                    else
                        MessageBox.Show(output);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục để lưu file";

                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    rootFolder = dialog.SelectedPath;

                    init_tree_file(rootFolder);

                }

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(selectedFilePath, richTextBox.Text);

            MessageBox.Show("Thành công");
        }

    }
}
