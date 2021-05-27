# Initial installation script (for Ubuntu (20.04) Linux or other OS with APT manager, for newest versions of ubuntu set the version code in the 'wget' URL)
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update;
sudo apt-get install -y apt-transport-https;
sudo apt-get install -y dotnet-sdk-3.1;
sudo apt-get install -y aspnetcore-runtime-3.1;

