output "cosmos_db_endpoint" {
    value = module.cosmos_db.endpoint
}

output "cosmos_db_primary_key" {
    value     = module.cosmos_db.primary_key
    sensitive = true
}

output "cosmos_db_connection_strings" {
    value     = module.cosmos_db.connection_strings
    sensitive = true
}