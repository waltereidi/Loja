/**
 * documentation
 * @link https://primevue.org/toast/
 */
export interface IConfigureToast{
    /** refers to toast color  */
    severity:ToastSeverity;
    /** refers to title */
    summary:string;
    /** refers to message content */
    detail:string;
    /** refers to duration in miliseconds */
    life: number;
}

export enum ToastSeverity {
    success , //green 
    info , //light blue
    warn, //orange 
    danger , //red
    secondary , //light gray
    contrast , //black
}