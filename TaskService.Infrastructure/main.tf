terraform {
    required_providers {
        hcloud = {
            source = "hetznercloud/hcloud"
            version = "1.60.0"
        }
    }
}

provider "hcloud" {
    token = var.hcloud_token
}

resource "hcloud_server" "server" {
    name = "TaskService"
    image = "ubuntu-24.04"
    server_type = "cx33"
    location = "nbg1"

    ssh_keys = [var.ssh_key_name]

    user_data = file("${path.module}/cloud-init.yaml")
}

output "server_ip" {
    value = hcloud_server.server.ipv4_address
}