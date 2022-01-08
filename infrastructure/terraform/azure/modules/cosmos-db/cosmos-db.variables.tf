variable "name" {
    description = "(Required) The name of the Cosmos DB."
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
