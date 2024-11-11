import { expect, test } from 'vitest'
import { LoggerController } from '@/pinia/Controllers/LoggerController'
import { LogSeverity } from '@/pinia/Dto/Log';

test('add log returns has error when add success false log', () => {
    const logger = new LoggerController("TestCase Log");

    logger.addLog('TestPurposes log' ,0  )
    logger.addLog('TestPurposes Log' , LogSeverity.Error )
    logger.addLog('TestPurposes Log' ,0)
    
    expect( logger.hasError() ).toBe(true)
    //An aditional log is inserted from logger contructor
    expect( logger.getLog().length ).toBe(4)
})
