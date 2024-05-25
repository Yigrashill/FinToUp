import React from 'react';
import logo from './logo.svg';
import './App.css';
import FinanceList from './Component/Finance/FinanceList';
import Navbar from './Component/Navbar';

function App() {
  return (
    <div className="App">
      <div className="w-full px-6 md:px-6 bg-sky-400 dark:bg-slate-900">
        <Navbar />
      <FinanceList />
      </div>
    </div>
  );
}

export default App;
