import React from 'react';
import { shallow } from 'enzyme';
import Submited from './Submited';

describe('Submited', () => {
  test('matches snapshot', () => {
    const wrapper = shallow(<Submited />);
    expect(wrapper).toMatchSnapshot();
  });
});
