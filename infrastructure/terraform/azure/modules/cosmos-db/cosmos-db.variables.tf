variable "name" {
    description = "(Required) The name of the Cosmos DB account."
    type        = string
}

variable "resource_group_name" {
    description = "(Required) The name of the resource group in which to create the Cosmos DB."
    type        = string
}

variable "location" {
    description = "(Required) Specifies the supported Azure location where the resource exists."
    type        = string
}

variable "database_name" {
    description = "(Required) Specifies the database name."
    type        = string
}

variable "container_name" {
    description = "(Required) Specifies the container name."
    type        = string
}
