import React, { createContext } from 'react';
import { isAuthenticated, login, logout } from '../services/auth';


const AuthContext = createContext({});


export const AuthProvider = ({ children }) => {
    
    return (

        <AuthContext.Provider value={{ 
            signed: isAuthenticated(),
            login, 
            logout,
        }}>
            { children }
        </AuthContext.Provider>
    )
}


export default AuthContext;