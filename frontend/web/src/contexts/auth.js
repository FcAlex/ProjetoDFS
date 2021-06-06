import React, { createContext } from 'react';
import { isAuthenticated, login, logout, getData } from '../services/auth';

const AuthContext = createContext({})

export const AuthProvider = ({ children }) => {
    return (

        <AuthContext.Provider value={{ 
            signed: isAuthenticated(),
            login,
            logout,
            getData
        }}>
            { children }
        </AuthContext.Provider>
    )
}


export default AuthContext;