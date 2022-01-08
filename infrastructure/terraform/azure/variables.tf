variable "resource_group_name" {
    description = "(Required) The name of the resource group."
    type        = string
}

variable "location" {
    description = "(Required) Specifies the supported Azure location."
    type        = string
}

variable "cosmos_db_name" {
    description = "(Required) The name of the Cosmos DB resource."
    type        = string
}
