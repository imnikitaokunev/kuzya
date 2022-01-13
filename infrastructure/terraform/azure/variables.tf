variable "resource_group_name" {
    description = "(Required) The name of the resource group."
    type        = string
}

variable "location" {
    description = "(Required) Specifies the supported Azure location."
    type        = string
}

variable "cosmosdb_account_name" {
    description = "(Required) The name of the Cosmos DB account."
    type        = string
}

variable "cosmosdb_database_name" {
    description = "(Required) The name of the Cosmos DB database."
    type        = string
}

variable "cosmosdb_container_name" {
    description = "(Required) The name of the Cosmos DB container."
    type        = string
}
