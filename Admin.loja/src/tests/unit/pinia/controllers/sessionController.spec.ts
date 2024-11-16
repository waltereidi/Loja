import { describe, it, expect, vi ,beforeEach , afterEach} from 'vitest';
import { SessionController } from '@/pinia/Controllers/sessionController';

describe('sessionStorage mock', () => {
    //SessionStorage mock
  beforeEach(() => {

    const mockStorage = {};
    vi.stubGlobal('sessionStorage', {
      getItem: vi.fn((key) => mockStorage[key] || null),
      setItem: vi.fn((key, value) => {
        mockStorage[key] = value;
      }),
      removeItem: vi.fn((key) => {
        delete mockStorage[key];
      }),
      clear: vi.fn(() => {
        for (const key in mockStorage) {
          delete mockStorage[key];
        }
      }),
    });
  });

  afterEach(() => {
    vi.restoreAllMocks();
  });

    it('set session and get Session',async ()=>{
        // sessionStorage is mocked by 'vitest-localstorage-mock'
       

        const session = new SessionController()
        const userInfo:UserInfo = {
            firstName:"testCase",
            lastName:"caseTest",
            nameInitials:"TC",
            jwtToken:{
                createdAt: new Date(),
                expiresAt: new Date()
            }
        };
        session.setUserInfoSession(userInfo);
        const result = session.getUserInfoSession()

        expect(sessionStorage.getItem).toBeCalledTimes(5);

        expect(userInfo).toMatchObject(result);
    })
});
