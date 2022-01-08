terraform {
    ## Azure state backend
    backend "azurerm" {
        resource_group_name = "terraformstate"
    }
}

## Azure resource provider ##
provider "azurerm" {
    features {}
}

resource "azurerm_resource_group" "rg" {
    name     = var.resource_group_name
    location = var.location
}

module "cosmos_db" {
    source = "./modules/cosmos-db"

    name = var.cosmos_db_name
    resource_group_name = azurerm_resource_group.rg.name
    location = azurerm_resource_group.rg.location
}
