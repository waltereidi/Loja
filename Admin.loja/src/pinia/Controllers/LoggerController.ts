import {Log , LogSeverity} from '@/pinia/Dto/Log'
export class LoggerController{
     
    constructor(serviceDescription:String){
        this.log.push({
            Severity : LogSeverity.Initialization,
            Description: `${serviceDescription}`,
            Created_At: new Date()
        })
    }

    log:Log[] = []
    /**
     * a single log with success = false tell the operation has failed
     * log with type should be used to improved legibility 
     * @param { bool } success 
     * @param { string } description 
     * @param { int } severity
     */    
    addLog = (description:String , severity:LogSeverity ):Number => this.log.push({
        Description : description ,
        Severity : severity , 
        Created_At : new Date()
    })

    /** 
     * Find if theres an error logged 
     */ 
    hasError = ():Boolean => this.log
        .some(x=>x.Severity === LogSeverity.Error )
    
     /**
     * get entireLog sorted by Id 
     * @returns []object
     */
     //@ts-ignore
    getLog =():Log[]=> this.log.sort((prev , next) => prev.Created_At - next.Created_At )
    

}