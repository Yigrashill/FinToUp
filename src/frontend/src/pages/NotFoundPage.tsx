import { Link } from "react-router-dom";
import { FaExclamationTriangle } from 'react-icons/fa';


const NotFoundPage = () => {
  return (
    <section className='text-center font-bold flex flex-col justify-center items-center h-96'>
      <div className="text-6xl ">
        <FaExclamationTriangle className='inline text-yellow-500 mr-4'  />
            404 Not Found
      </div>
   

        <p className='text-xl mb-5'>This page does not exist</p>
            <Link
                to='/'
                className='text-white bg-indigo-700 hover:bg-indigo-900 rounded-md px-3 py-2 mt-4'>
                Go Back
            </Link>
    </section>
  )
}

export default NotFoundPage