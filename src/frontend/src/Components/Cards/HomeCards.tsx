import { Link } from 'react-router-dom';
import Card from './Card'

const HomeCards = () => {
  return (
    <section className='py-4'>
    <div className='container-xl lg:container m-auto'>
        <div className='grid grid-col-1 md:grid-cols-2 gap-4 p-4 rounded0lg'>
          <Card>
            <h2 className='text-2xl font-bold'> For Developers</h2>
            <p className='mt-2 mb-4'>
              Browse our React jobs and start your career today
            </p>
            <Link to="/jobs"
              className='inline-block bg-black text-white rounded-lg px-4 py-2 hover:bg-gray-700'>
              Browse Jobs
            </Link>
          </Card>
          <Card bg='bg-indigo-200'>
            <h2 className='text-2xl font-bold'>For Employers</h2>
              <p className='mt-2 mb-4'>
                List your job to find the perfect developer for the role
              </p>
              <h1 className='text-3xl mb-4'>New thinks you might do</h1>
            <Link to='/add-job'
              className='inline-block bg-green-600 text-white rounded-lg px-4 py-2 hover:bg-green-900'>
              Add Job
            </Link>
          </Card>

        </div>
        
    </div>            
  </section>

  );
};

export default HomeCards