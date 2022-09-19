export class StorageUtil{

    public static saveStorage<T>(key: string, value: T): void {
        localStorage.setItem(key, JSON.stringify(value));
    }
    
    public static readStorage<T>(key: string): T | undefined {
        const storedValue = localStorage.getItem(key);
        try {
            if(storedValue){
                return JSON.parse(storedValue) as T;
            }
            
            return undefined;
            
        }
        catch(e) {
            localStorage.removeItem(key);
            return undefined;
        }
    
        
    }

}
