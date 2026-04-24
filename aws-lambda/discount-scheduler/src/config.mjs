function parseBoolean(value, defaultValue) {
    if(value === undefined || value === null || value === '') {
        return defaultValue;
    }
    return value.toLowerCase()=== "true"
}

function requireEnv(name){
    const value = process.env[name];
    if(!value || value.trim().length === 0){
        throw new Error(`Require environment "${name}" is required`);
    }
    return value.trim();
}

export function loadConfig(){
    return{
        dbHost: requireEnv("DB_HOST"),
        dbPort: Number.parseInt(process.env.DB_PORT ?? "1433", 10),
        dbUser: requireEnv("DB_USER"),
        dbPassword: requireEnv("DB_PASSWORD"),
        dbName: requireEnv("DB_NAME"),
        dbEncrypt: parseBoolean(process.env.DB_ENCRYPT, true),
        dbTrustServerCertificate: parseBoolean(process.env.DB_TrustServerCertificate,true)
    }
}