import React from 'react'
import Navbar from '../Component/Navbar'
import Hero from '../Component/Hero'
import FinanceList from '../Component/Finance/FinanceList'

const MainLayout = () => {
  return (
    <div className="w-full px-6 md:px-6 bg-sky-400 dark:bg-slate-900">
      <Navbar />
    
      <Hero />

    </div>
  )
}

export default MainLayout