import React from 'react'
import { Link, NavLink } from 'react-router-dom';
import logo from '../images/logo.png';

const Navbar = () => {

  return (
      <nav className ='bg-gray-800 pt-10 '>
          <div className='mx-auto max-w-7xl sm:px-6 lg:px-8'>
              <div className='h-20 items-center justify-between'>
                  <div className='flex text-zinc-200  items-center justity-center md:items-strecht md:justify-start'>
                      <Link to='/home' className='flex flex-shrink=0 items-center mr-4 ' >
                      <span className='hidden md:block bg-gray-950 hover:bg-gray-900 p-2 px-6 rounded-3xl text-2xl font-bold ml-2'>
                          Fin To Up 2
                      </span>
                      </Link>
                      <div className='md:ml-auto justify-center font-sans font-bold'>
                          <div className="relative bg-green-800 hover:bg-green-900 p-2 px-5 rounded-2xl">
                              <NavLink to='/Dashbord'>Dashbord</NavLink>
                          </div>
                          <div className="absolute bg-green-800 hover:bg-green-900 p-2 px-5 rounded-3xl">
                              <NavLink to='/Dashbord'>Dashbord</NavLink>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </nav>
  );
};

export default Navbar;