
export interface Log{
    Description:String ,
    Severity:LogSeverity, 
    Created_At:Date
}
/**
 * This interface is sensitive to order 
 * starts in lower severity and end in highest severity
 */
export enum LogSeverity{
    Event ,
    Initialization ,
    Parameter, 
    Error, 
}